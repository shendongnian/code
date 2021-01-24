      public override void OnChanged()
            {
                base.OnChanged();
                Console.WriteLine("Change was observerd");
    
                // This area is hit, but how do I call the Redraw method above? It is out of scope
    
                MessagingCenter.Send<object>(this, "needRedraw");
    
            }
