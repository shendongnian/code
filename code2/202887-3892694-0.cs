    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class TextBoxFilter
    {
    	[Flags()]
    	public enum Filters
    	{
    		None = 0,
    		Text = 1,
    		Numbers = 2,
    		AlphaNumeric = Filters.Text | Filters.Numbers,
    		Currency = 4,
    		All = Filters.Text | Filters.Numbers | Filters.Currency
    	}
    
    	Dictionary<TextBox, Filters> _keyFilter;
    	Dictionary<TextBox, string> _allowedKeys;
    	Dictionary<TextBox, string> _invalidKeys;
    
    	Dictionary<TextBox, Windows.Forms.KeyEventArgs> keyEventArgs;
    	private static string DecimalMark = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    	private static string NegativeMark = Application.CurrentCulture.NumberFormat.NegativeSign;
    	private static string CurrencySymb = Application.CurrentCulture.NumberFormat.CurrencySymbol;
    
    	private static string CurrencyDecimal = Application.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
    
    	public TextBoxFilter()
    	{
    		_keyFilter = new Dictionary<TextBox, Filters>();
    		_allowedKeys = new Dictionary<TextBox, string>();
    		_invalidKeys = new Dictionary<TextBox, string>();
    		keyEventArgs = new Dictionary<TextBox, KeyEventArgs>();
    	}
    
    //set & remove filter
    
    	public void SetTextBoxFilter(TextBox textBox, Filters filter)
    	{
    		SetTextBoxFilter(textBox, filter, AllowedKeys(textBox), InvalidKeys(textBox));
    	}
    
    	public void SetTextBoxFilter(TextBox textBox, string allowedKeys)
    	{
    		SetTextBoxFilter(textBox, Strings.Filter(textBox), allowedKeys, InvalidKeys(textBox));
    	}
    
    
    	public void SetTextBoxFilter(TextBox textBox, string allowedKeys, string invalidKeys)
    	{
    		SetTextBoxFilter(textBox, Strings.Filter(textBox), allowedKeys, invalidKeys);
    	}
    
    
    	public void SetTextBoxFilter(TextBox textBox, Filters filter, string allowedKeys, string invalidKeys)
    	{
    		if (!_keyFilter.ContainsKey(textBox)) {
    			//add the textbox and its filter if it does not exist in 
    			//the collection of registered textboxes
    			_keyFilter.Add(textBox, filter);
    			_allowedKeys.Add(textBox, allowedKeys);
    			_invalidKeys.Add(textBox, invalidKeys);
    			keyEventArgs.Add(textBox, new System.Windows.Forms.KeyEventArgs(Keys.None));
    
    			//add the event handlers
    			textBox.KeyDown += KeyDownUp;
    			textBox.KeyUp += KeyDownUp;
    			textBox.KeyPress += KeyPress;
    			textBox.Validating += Validating;
    			textBox.Disposed += Disposed;
    
    		} else {
    			//change the filter of the textbox if it exists in
    			//the collection of registered textboxes
    			_keyFilter(textBox) = filter;
    			_allowedKeys(textBox) = allowedKeys;
    			_invalidKeys(textBox) = invalidKeys;
    		}
    	}
    
    	public void RemoveTextBoxFilter(TextBox textBox)
    	{
    		if (_keyFilter.ContainsKey(textBox)) {
    			_keyFilter.Remove(textBox);
    			_allowedKeys.Remove(textBox);
    			_invalidKeys.Remove(textBox);
    			keyEventArgs.Remove(textBox);
    
    			textBox.KeyDown -= KeyDownUp;
    			textBox.KeyUp -= KeyDownUp;
    			textBox.KeyPress -= KeyPress;
    			textBox.Validating -= Validating;
    			textBox.Disposed -= Disposed;
    		}
    	}
    
    	public bool ContainsTextBox(TextBox textBox)
    	{
    		return _keyFilter.ContainsKey(textBox);
    	}
    
    //properties
    
    	public Filters Filter {
    		get {
    			if (ContainsTextBox(textBox)) {
    				return _keyFilter.Item[textBox];
    			} else {
    				return Filters.None;
    			}
    		}
    		set { SetTextBoxFilter(textBox, value); }
    	}
    
    	public string AllowedKeys {
    		get {
    			if (ContainsTextBox(textBox)) {
    				return _allowedKeys(textBox);
    			} else {
    				return "";
    			}
    		}
    		set { SetTextBoxFilter(textBox, this.Filter(textBox), value, this.InvalidKeys(textBox)); }
    	}
    
    	public string InvalidKeys {
    		get {
    			if (ContainsTextBox(textBox)) {
    				return _invalidKeys(textBox);
    			} else {
    				return "";
    			}
    		}
    		set { SetTextBoxFilter(textBox, this.Filter(textBox), this.AllowedKeys(textBox), value); }
    	}
    
    //event handlers
    
    	private void Disposed(object sender, System.EventArgs e)
    	{
    		RemoveTextBoxFilter((TextBox)sender);
    	}
    
    	private void KeyDownUp(object sender, System.Windows.Forms.KeyEventArgs e)
    	{
    		//assign the modifiers
    		keyEventArgs((TextBox)sender) = e;
    	}
    
    	private void KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    	{
    		//ensure key pressed is in the allowed keys
    
    		object txt = (TextBox)sender;
    		object c = e.KeyChar;
    		bool allowKey = IsValidChar(txt, c, txt.SelectionStart);
    
    
    		//check for backspace & Ctrl combinations if the allowKey is still false
    		if (allowKey == false) {
    			if (keyEventArgs(txt).Control) {
    				//control modifier goes with A, X, C, V and Z for 
    				//Select All, Cut, Copy, Paste and Undo respectively
    				object key = keyEventArgs(txt).KeyCode;
    				allowKey = (key == Keys.A || key == Keys.X || key == Keys.C || key == Keys.V || key == Keys.Z);
    
    			} else if (keyEventArgs(txt).KeyCode == Keys.Back) {
    				//allow the backspace key
    				allowKey = true;
    			}
    		}
    
    
    		//disable the key if it was not valid
    		if (!allowKey) {
    			e.Handled = true;
    			Interaction.Beep();
    		}
    	}
    
    	private void Validating(object sender, System.ComponentModel.CancelEventArgs e)
    	{
    		object box = (TextBox)sender;
    		object boxFlags = _keyFilter(box);
    
    		//skip validation if the textbox allows all entries or there is no text
    		if (boxFlags == Filters.All | string.IsNullOrEmpty(box.Text))
    			return;
    
    		//otherwise check the characters entered
    		object txtChars = box.Text.ToCharArray;
    
    		bool isValidEntry = false;
    
    		//check each caracter for an invalid entry
    		for (i = 0; i <= txtChars.Length - 1; i++) {
    			object c = txtChars(i);
    			isValidEntry = IsValidChar(box, txtChars(i), i);
    
    			if (!isValidEntry) {
    				box.Select(i, 1);
    				break; // TODO: might not be correct. Was : Exit For
    			}
    		}
    
    		if (!isValidEntry)
    			e.Cancel = true;
    
    		if (!isValidEntry) {
    			Interaction.MsgBox("The text entered is invalid for the format " + boxFlags.ToString + "." + !string.IsNullOrEmpty(_allowedKeys(box)) ? Constants.vbCrLf + "Additional Allowed Keys: " + _allowedKeys(box) : "" + !string.IsNullOrEmpty(_invalidKeys(box)) ? Constants.vbCrLf + "Additional Invalid Keys: " + _invalidKeys(box) : "", MsgBoxStyle.Critical, "Invalid Entry");
    		}
    	}
    
    	private bool IsValidChar(TextBox textBox, char c, int charIndex)
    	{
    		//ensure key pressed is in the allowed keys
    
    		object pF = _keyFilter(textBox);
    		object aK = _allowedKeys(textBox);
    		object iK = _invalidKeys(textBox);
    		bool shouldAllow = false;
    
    
    		//if filter is set to all, return true unconditionally
    		if (pF == Filters.All)
    			return true;
    
    
    		//check preset filters
    
    		//check for text
    		if (EnumHasFlag(pF, Filters.Text)) {
    			if (!char.IsDigit(c)) {
    				shouldAllow = true;
    			} else {
    				//if the character is a digit, check for the number flag (AlphaNumerics)
    				if (EnumHasFlag(pF, Filters.Numbers)) {
    					shouldAllow = true;
    				}
    			}
    
    		}
    
    		//check for nubers
    		if (shouldAllow == false && EnumHasFlag(pF, Filters.Numbers)) {
    			if (char.IsDigit(c)) {
    				shouldAllow = true;
    			} else if (DecimalMark.Contains(c)) {
    				//allow the decimal if there is no decimal in the textbox's
    				//text or the selected text contains the mark
    				if (!textBox.Text.Substring(0, charIndex).Contains(c) || textBox.SelectedText.Contains(c)) {
    					shouldAllow = true;
    				}
    			} else if (NegativeMark.Contains(c) && (charIndex <= NegativeMark.IndexOf(c))) {
    				//allow the negative mark if we are at the start of the
    				//textbox
    				shouldAllow = true;
    			}
    
    		}
    
    		//check for currency
    		if (shouldAllow == false && EnumHasFlag(pF, Filters.Currency)) {
    			if (char.IsDigit(c)) {
    				shouldAllow = true;
    			} else if (CurrencyDecimal.Contains(c)) {
    				//allow the currency decimal mark if it does not exist in the
    				//textbox's text or the selected text contains the mark
    				if (!textBox.Text.Substring(0, charIndex).Contains(c) || textBox.SelectedText.Contains(c)) {
    					shouldAllow = true;
    				}
    			} else if (CurrencySymb.Contains(c) && (charIndex <= CurrencySymb.IndexOf(c))) {
    				//allow the currency symbol if we are in a valid position
    				shouldAllow = true;
    			}
    
    		}
    
    
    
    		//now check for extra allowed keys
    		if (!shouldAllow) {
    			shouldAllow = aK.Contains(c);
    		}
    
    		//and then check for extra invalid keys
    		if (shouldAllow && iK.Contains(c)) {
    			shouldAllow = false;
    		}
    
    
    		return shouldAllow;
    	}
    
    	[System.Diagnostics.DebuggerStepThrough()]
    	private bool EnumHasFlag(Enum value, Enum flag)
    	{
    		return (Convert.ToInt64(value) & Convert.ToInt64(flag)) == Convert.ToInt64(flag);
    	}
    }
