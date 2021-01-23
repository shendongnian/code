	void Main()
	{
		Application.Run(new Form2());
	}
	
	public class Form2:Form
	{
	public Form2()
		{
			Label lbl= new Label();
			lbl.Location = new Point(200,40);
			this.Controls.Add(lbl);
			FlowLayoutPanel fl = new FlowLayoutPanel();fl.AutoScroll =true;
			fl.MouseMove += (s,e) => { lbl.Text = e.Location.Y.ToString();};
			this.MouseMove += (s,e) => { lbl.Text = e.Location.Y.ToString();};
			for(int i=0;i<10;i++){fl.Controls.Add(new Button());}
			this.Controls.Add(fl);
			
		}
	}
