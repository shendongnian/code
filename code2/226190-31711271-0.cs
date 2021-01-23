    public class Form123456 : Form {
    
    	public Form123456() {
    		Controls.Add(new UC1());
    	}
    
    	public class UC1 : UserControl {
    		Button b1 = new Button { Text = "Button1" };
    		Label lb = new Label { Text = "_", AutoSize = true, BackColor = Color.Red };
    		Button b2 = new Button { Text = "Button2", Visible = false };
    		Button b2b = new Button { Text = "x" };
    		Button b3 = new Button { Text = "Button3" };
    		public UC1() {
    			AutoScroll = true;
    			Dock = DockStyle.Fill;
    			b1.Location = new Point(0, 200);
    			b2.Location = new Point(0, 600);
    			lb.Location = new Point(70, 600);
    			b2b.Location = new Point(90, 600);
    			b3.Location = new Point(0, 800);
    			Controls.Add(b1);
    			Controls.Add(b2);
    			Controls.Add(lb);
    			Controls.Add(b2b);
    			Controls.Add(b3);
    
    			lb.MouseEnter += delegate {
    				b2.Visible = true;
    			};
    			lb.MouseLeave += delegate {
    				b2.Visible = false;
    			};
    		}
    	}
    }
