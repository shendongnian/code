	class MyEntryElement : EntryElement {
		
		public MyEntryElement (string c, string p, string v) : base (c, p, v)
		{
			MaxLength = -1;
		}
		
		public int MaxLength { get; set; }
		
		protected override UITextField CreateTextField (RectangleF frame)
		{
			UITextField tf = base.CreateTextField (frame);
			tf.ShouldChangeCharacters += delegate (UITextField textField, NSRange range, string replacementString) {
				if (MaxLength == -1)
					return true;
				
				return textField.Text.Length + replacementString.Length - range.Length <= MaxLength;
			};
			return tf;
		}
	}
