		private void path_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.KeyStates == Keyboard.GetKeyStates(Key.Up))
			{
			var clipGeom = ((Geometry)this.Resources["mountain"]).Clone();
			var yTransform = new TranslateTransform();
			clipGeom.Transform = yTransform;
			Color.Clip = clipGeom;
			var yAnim = new DoubleAnimation { From = 0, To = 900, Duration= new Duration(TimeSpan.FromMilliseconds(9000)) };
			yTransform.BeginAnimation(TranslateTransform.YProperty, yAnim);
			}
		}
