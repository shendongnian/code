            int n = 10;
			   Panel[] p=new Panel[n];
			   int j = 10;
			   for (int i=0;i<n;i++)
			   {
					j += 10;
					p[i] = new Panel();
					p[i].BorderStyle = BorderStyle.Fixed3D;
					p[i].Height = 100;
					p[i].Location = new Point(100,10+j);
					this.Controls.Add(p[i]);
			   }
