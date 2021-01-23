        for(int i = 0; i < Resources.Count; i ++)
        {
            Button btn = Resources[i] as Button; // btn will be null if not a Button
            
            if( btn != null )
            {
                btn.IsEnabled = false;
            }
        }
