            Size sizeShape = new Size("SomeWidth" , "SomeHeight");
            List<Retangle> rects = new List<Retangle>(); 
            
            Random r = new Random();
            
        while(rects.count != "someCount")
        {
            Point rPoint = new Point(r.Next(500) , rNext(500))
            bool isNew = true;
            foreach(Rectangle r in rects)
            {
                if(r.contains(new Point(newX , newY))
                    isNew = false;
            }
            if(isNew)
               rects.Add(GetRect(rPoint  , sizeShape)); 
        }
          
            private Rectangle GetRect(Point p , Size s)
            {
                return new Rectangle(p,s);
            }
