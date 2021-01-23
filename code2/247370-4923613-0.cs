	void Main()
	{
		Application.Run(new Form1());
	}
	
	public class Form1 :Form
	{	
		float time3 =0, time =0,time2=1000000,height=20,width=20;int a = -1;
		PointF Location = new PointF(0,0);
		PointF Velocity = new PointF(50,50);
		DateTime dt;
		float x=0;
		System.Timers.Timer tmr = new System.Timers.Timer();
		System.Timers.Timer gmlp = new System.Timers.Timer();
		public Form1()
		{
			this.Size = new Size(700,700);		
			Label lb = new Label();
			
			tmr.Interval =20;
			tmr.Elapsed += (s,e) => {	
			
				//if(Location.X >= 500) Velocity.X *= a;
			
				//if(time3 >= 1000) time=0; else 
				time3 +=20;// (DateTime.Now.Ticks - dt.Ticks)/10000;
				Location.X = Velocity.X * (time3/1000);
				Location.Y = Velocity.Y * (time3/1000);
				this.Invalidate();
				if(time >= time2) {tmr.Stop(); tmr.Enabled = false; gmlp.Stop(); gmlp.Enabled = false;}
			};
			this.DoubleBuffered =true;
			
			
			gmlp.Interval = 1000;
			gmlp.Elapsed += (s,e) => {
				//dt = dt.AddSeconds(1);
				lb.Text =  
				"time: " + time + 
				"\ntime2: " + time2 +
				"\ntime3: " +time3 + 
				"\nlocx: " +Location.X +
				"\ntimespan: " + (DateTime.Now.Ticks - dt.Ticks)/10000 + 
				"\nx moved: " + (Location.X - x);
			};
			gmlp.Enabled = true;
			gmlp.Start();
			tmr.Enabled =true;
			tmr.Start();
			lb.Location = new Point(20,20);
			lb.Size = new Size(80,200);
			this.Controls.Add(lb);
			dt = DateTime.Now;
		}
	
		protected override void OnPaint(PaintEventArgs pe)
		{    
			base.OnPaint(pe);
			pe.Graphics.FillEllipse(Brushes.Tomato, new Rectangle((int)Location.X,(int)Location.Y,(int)height,(int)width));		
		}
	}
