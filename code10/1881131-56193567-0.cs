            checkedListBox1.Items.Clear();
			checkedListBox1.Text = "";
			checkedListBox1.DisplayMember = "Text";
			checkedListBox1.ValueMember = "Value";
			checkedListBox1.Items.Insert(0,
					new { Text = "Rawr", Value = "Whatever 2011"});
			string temp = checkedListBox1.Items[0].ToString(); //gets the string of the item. (switch 0 to the index you want)
			string string_Value = temp.Split(new string[] { "Value = " }, StringSplitOptions.None)[1]; //splits the string by the value part and returns the string value.
			string_Value = string_Value.Substring(0, string_Value.Length - 2); ; //removes the last 2 characters since they are not part of the value.
			//you now have the value in string form.
