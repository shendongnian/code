    var task1  = Task.Factory.StartNew( () => { 
    								  This.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
    								  {	
    									string ImagePath="";
    								    pictureBox1.Image = Image.FromFile(ImagePath);
    								    .......
    								  });	
    							       } 
    						  );
