    public partial class Form1 : Form {
    	public Form1() {
    		InitializeComponent();
    
    		this.Paint += new PaintEventHandler(Form1_Paint);
    		this.SizeChanged += new EventHandler(Form1_SizeChanged);
    	}
    
    	void Form1_SizeChanged(object sender, EventArgs e) {
    		this.Invalidate();
    	}
    
    	public class RichText {
    		public Font Font { get; set; }
    		public Color? TextColor { get; set; }
    		public string Text { get; set; }
    
    		public RichText() { }
    		public RichText(string text) {
    			this.Text = text;
    		}
    		public RichText(string text, Font font) : this(text) {
    			this.Font = font;
    		}
    		public RichText(string text, Color textColor) : this(text) {
    			this.TextColor = textColor;
    		}
    		public RichText(string text, Color textColor, Font font) : this(text, textColor) {
    			this.Font = font;
    		}
    	}
    	void Form1_Paint(object sender, PaintEventArgs e) {
    		var arial_8 = new Font("Arial", 8);
    		var webdings_10 = new Font("Webdings", 10);
    
    		var richTexts = new RichText[]{
    			new RichText("Default text.")
    			, new RichText("Default green text.", Color.Green)
    			, new RichText("Regular arial 8.", arial_8)
    			, new RichText("Bold arial 8.", new Font(arial_8, FontStyle.Bold))
    			, new RichText("Regular webdings 10.", webdings_10)
    			, new RichText("Regular blue webdings 10.", Color.Blue, webdings_10)
    		};
    
    		var g = e.Graphics;
    
    		Point textPosition = new Point(0, 0);
    		int maxWidth = this.ClientSize.Width;
    		foreach (var richText in richTexts) {
    			var text = richText.Text;
    			if (string.IsNullOrEmpty(text)) { continue; }
    
    			var font = richText.Font ?? Control.DefaultFont;
    			var textColor = richText.TextColor ?? Control.DefaultForeColor;
    
    			using (var brush = new SolidBrush(textColor)) {
    				var rslt_Measure = g.MeasureString(text, font);
    				if (rslt_Measure.Width + textPosition.X > maxWidth) {
    					// this code does not solve word-wraping
    					var rslt_Line = g.MeasureString("\r\n", font);
    					Point tmpTextPosition = new Point(0, textPosition.Y + (int)rslt_Line.Height);
    
    					g.DrawString(text, font, brush, tmpTextPosition);
    					var newPosition = tmpTextPosition;
    					newPosition.X += (int)rslt_Measure.Width;
    					textPosition = newPosition;
    				}
    				else {
    					g.DrawString(text, font, brush, textPosition);
    					var newPosition = textPosition;
    					newPosition.X += (int)rslt_Measure.Width;
    					textPosition = newPosition;
    				}
    			}
    		}
    	}
    }
