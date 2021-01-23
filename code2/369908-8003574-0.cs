    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace ComboBoxMod
    {
    	static class Program
    	{
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new frmMain());
    		}
    	}
    
    	public partial class frmMain : Form
    	{
    		private ComboBoxMod.ComboBox cbTest; //this is the modified combo box
    		private System.Windows.Forms.Button btnToggleAlign;
    		private System.ComponentModel.IContainer components = null;
    
    		public frmMain()
    		{
    			this.cbTest = new ComboBoxMod.ComboBox();
    			this.btnToggleAlign = new Button();
    
    			InitialiseComponent();
    			
    			for (int i = 0; i < 50; i++)
    			{
    				cbTest.Items.Add(i);
    			}
    		}
    
    		void btnToggleAlign_Click(object sender, EventArgs e)
    		{
    			if (this.cbTest.CASScrollAlignment == ComboBox.Alignment.CASRight) //If Right Aligned
    			{
    				this.cbTest.CASScrollAlignment = ComboBox.Alignment.CASLeft; //Set To Left
    			}
    		}
    
    		private void InitialiseComponent()
    		{
    			this.SuspendLayout();
    
    			this.cbTest.FormattingEnabled = true;
    			this.cbTest.Location = new System.Drawing.Point(12, 12);
    			this.cbTest.Name = "cbTest";
    			this.cbTest.Size = new System.Drawing.Size(180, 21);
    			this.cbTest.TabIndex = 0;
    
    			this.btnToggleAlign.Location = new System.Drawing.Point(12, 42);
    			this.btnToggleAlign.Name = "btnScrollAlign";
    			this.btnToggleAlign.Size = new System.Drawing.Size(180, 23);
    			this.btnToggleAlign.TabIndex = 0;
    			this.btnToggleAlign.Text = "Toggle Scrollbar Alignment";
    			this.btnToggleAlign.UseVisualStyleBackColor = true;
    			this.btnToggleAlign.Click += new EventHandler(btnToggleAlign_Click);
    
    			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    			this.ClientSize = new System.Drawing.Size(200, 75);
    
    			this.Controls.Add(this.cbTest);
    			this.Controls.Add(this.btnToggleAlign);
    
    			this.Name = "frmMain";
    			this.Text = "frmMain";
    			this.ResumeLayout(false);
    		}
    
    		protected override void Dispose(bool disposing)
    		{
    			if (disposing && (components != null))
    			{
    				components.Dispose();
    			}
    			base.Dispose(disposing);
    		}
    	}
    
    	public class ComboBox : System.Windows.Forms.ComboBox //Inherits ComboBox
    	{
    		[DllImport("user32", CharSet = CharSet.Auto)]
    		public extern static int GetWindowLong(IntPtr hwnd, int nIndex); //Retrieve Info About Specified Window
    
    		[DllImport("user32")]
    		public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong); //Change An Attribute Of Specified Window
    
    		[DllImport("user32.dll")]
    		public static extern int GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi); //Retrieve Info About Specified Combo Box
    
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct COMBOBOXINFO //Contains ComboBox Status Info
    		{
    			public Int32 cbSize;
    			public RECT rcItem;
    			public RECT rcButton;
    			public ComboBoxButtonState caState;
    			public IntPtr hwndCombo;
    			public IntPtr hwndEdit;
    			public IntPtr hwndList;
    		}
    
    
    		[StructLayout(LayoutKind.Sequential)] //Describes Width, Height, And Location Of A Rectangle
    		public struct RECT
    		{
    			public int Left;
    			public int Top;
    			public int Right;
    			public int Bottom;
    		}
    
    		public enum ComboBoxButtonState //Determines Current State Of ComboBox
    		{
    			STATE_SYSTEM_NONE = 0,
    			STATE_SYSTEM_INVISIBLE = 0x00008000,
    			STATE_SYSTEM_PRESSED = 0x00000008
    		}
    
    		/// <summary> 
    		/// Alignment Enum For Left & Right
    		/// </summary> 
    		public enum Alignment
    		{
    			CASLeft = 0,
    			CASRight = 1
    		}
    		
    		/// <summary> 
    		/// Align ScrollBar 
    		/// </summary> 
    		public Alignment CASScrollAlignment
    		{
    			get
    			{
    				return CASScroll; //Get Value
    			}
    			set
    			{
    				if (CASScroll == value) //If Not Valid Value
    					return;
    
    				CASScroll = value; //Set Value
    				AlignScrollbar(); //Call AlignScroll Method
    			}
    		}
    
    		private const int GWL_EXSTYLE = -20; //ComboBox Style
    		private const int WS_EX_RIGHT = 4096; //Right Align Text 
    		private const int WS_EX_LEFTSCROLLBAR = 16384; //Left ScrollBar
    
    		private IntPtr CASHandle; //Handle Of ComboBox
    		private Alignment CASScroll; //Alignment Options For ScrollBar
    
    
    		public ComboBox()
    		{
    			CASHandle = CASGetHandle(this); //Get Handle Of ComboBox
    			CASScroll = Alignment.CASRight; //default alignment
    		}
    
    		/// <summary>
    		/// Retrieves ComboBox Handle
    		/// </summary>
    		/// <param name="CASCombo"></param>
    		/// <returns></returns>
    		public IntPtr CASGetHandle(ComboBox CASCombo)
    		{
    
    			COMBOBOXINFO CASCBI = new COMBOBOXINFO(); //New ComboBox Settings Object
    			CASCBI.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(CASCBI); //Call In Correct Size
    			GetComboBoxInfo(CASCombo.Handle, ref CASCBI); //Obtain Handle
    			return CASCBI.hwndList; //Return Handle
    		}
    
    		/// <summary>
    		/// Align The ComboBox ScrollBar
    		/// </summary>
    		private void AlignScrollbar()
    		{
    			if (CASHandle != IntPtr.Zero) //If Valid Handle
    			{
    				int CASStyle = GetWindowLong(CASHandle, GWL_EXSTYLE); //Get ComboBox Style
    				switch (CASScroll)
    				{
    					case Alignment.CASLeft:
    						CASStyle = CASStyle | WS_EX_LEFTSCROLLBAR; //Align ScrollBare To The Left
    						break;
    				}
    				SetWindowLong(CASHandle, GWL_EXSTYLE, CASStyle); //Apply On ComboBox
    			}
    		}
    	}
    }
    
