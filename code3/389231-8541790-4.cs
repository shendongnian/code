    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
    	// Default all textboxes as string value instead of null
    	[DefaultValue("")]
    	public class MyTextbox : TextBox
    	{
    		// designer serialization is another alternative to preveting the IDE to analyze controls
    		// at design time, but for other tighter controls, leave explicitly as READONLY...
    		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    		[ReadOnly(true)]
    		public override Font Font
    		{ get { return MyConstants.MyFontBase; } }
    
    		[ReadOnly(true)]
    		public override Color ForeColor
    		{ get { return Color.Red; } }
    
    		[ReadOnly(true)]
    		protected override Padding DefaultPadding
    		{ get { return MyConstants.MyPadding; } }
    
    		// Now, on to the rest of the class definition and interaction if editing mode changed
    		public MyTextbox()
    		{
    			base.Font = Font;
    		}
    		
    	}
    
    	/// <summary>
    	/// constants used for common look / feel application wide for all controls
    	/// such as textbox, label, buttons, comboboxes, etc...
    	/// </summary>
    	public class MyConstants
    	{
    		public static readonly Color MyColorBlue = Color.Blue;
    		public static readonly Color MyFontForeColor = Color.Black;
    		// public static readonly Color MyFontForeColorDisabled = Color.FromArgb(38, 146, 210);
    		public static readonly Color MyFontForeColorDisabled = Color.Gray;
    		public static readonly Color MyBackColorFieldRequired = Color.LightBlue;
    		public static readonly Color MyBackColorFieldInvalid = Color.Red;
    		public static readonly Color MyBackColorFieldNormal = Color.White;
    		public static readonly String MyFontBaseName = "Arial";
    		public static readonly float MyFontBaseSizeHdr = 16F;
    		public static readonly float MyFontBaseSizeSubHdr = 11F;
    		public static readonly float MyFontBaseSize = 14F;
    		public static readonly Font MyFontBase = new Font(MyFontBaseName, MyFontBaseSize, FontStyle.Regular, GraphicsUnit.Point);
    		public static readonly Font MyFontItalic = new Font(MyFontBaseName, MyFontBaseSize, FontStyle.Italic, GraphicsUnit.Point);
    		public static readonly Size MyButtonSize = new Size(80, 25);
    		public static readonly Padding MyPadding = new Padding(2, 0, 2, 0);
    	}
    
    }
