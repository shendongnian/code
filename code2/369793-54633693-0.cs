    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Timer = System.Threading.Timer;
    
    	internal class DelayedText : IDisposable
    	{
    		private readonly EventHandler _onTextChangedDelayed;
    		private readonly TextBox _textBox;
    		private readonly int _period;
    		private Timer _timer;
    
    		public DelayedText(TextBox textBox, EventHandler onTextChangedDelayed, int period = 250)
    		{
    			_textBox = textBox;
    			_onTextChangedDelayed = onTextChangedDelayed;
    			_textBox.TextChanged += TextBoxOnTextChanged;
    			_period = period;
    		}
    
    		public void Dispose()
    		{
    			_timer?.Dispose();
    			_timer = null;
    		}
    
    		private void TextBoxOnTextChanged(object sender, EventArgs e)
    		{
    			Dispose();
    			_timer = new Timer(TimerElapsed, null, _period, Timeout.Infinite);
    		}
    
    		private void TimerElapsed(object state)
    		{
    			_onTextChangedDelayed(_textBox, EventArgs.Empty);
    		}
    	}
