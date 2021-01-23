    		int _x = 0;
		private void button1_MouseMove(object sender, MouseEventArgs e)
		{
			if(_x == 0)
			{
				_x = e.X;
			}
			int move = 0;
			Point p;
			if (e.X <= _x)
			{
				move = _x - e.X;
				p = new Point(panel2.Location.X - move, panel2.Location.Y);
			}
			else
			{
				move = e.X - _x;
				p = new Point(panel2.Location.X + move, panel2.Location.Y);
			}
			panel2.Location = p;
		}
