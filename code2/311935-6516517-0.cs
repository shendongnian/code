    textBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(textBox_MouseWheel);
    			
    		void resultBox_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
    		{
    			if (e.Delta > 0)
    				;// next student.
    			else ; // prev student.
    		}
