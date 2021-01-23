            public List<MyClass> GetBiggestNotOverlapping(ICollection<MyClass> elements)
            {
                var result = new List<MyClass>();
                var boundary = 0;
                var stop = false;
                while(!stop)
                {
                    var nextElement = (from element in elements
                                   where element.Y >= boundary
                                   orderby element.Height descending, element.X ascending
                                   select element).FirstOrDefault();
                    if (nextElement != null)
                    {
                        result.Add(nextElement);
                        boundary = nextElement.Y + nextElement.Height; // bot
                    }
                    else
                    {
                        stop = true;
                    }
                }
                return result;
            }
