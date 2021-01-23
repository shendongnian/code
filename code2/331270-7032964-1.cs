    public List<MyClass> GetBiggestNotOverlapping(ICollection<MyClass> elements)
    {
        var result = new List<MyClass>();
        var boundary = 0;
        var stop = false;
        Func<MyClass, MyClass, bool> inTheSameLane = (first, second) =>
            ((first.Left >= second.Left && first.Left <= second.Right) ||
            (first.Right <= second.Right && first.Right >= second.Left));
        while(!stop)
        {
            var nextElement = (from element in elements
                               where element.Top >= boundary &&
                                    // and where we are NOT "jumping over" any element in the same lane:
                                    // there is no element whose "left" falls between
                                    !(from otherElement in elements
                                      where otherElement != element &&
                                      inTheSameLane(element, otherElement) &&
                                      otherElement.Top < element.Top
                                      select otherElement).Any()
                               orderby element.Height descending, element.Left ascending
                               select element).FirstOrDefault();
            if (nextElement != null)
            {
                result.Add(nextElement);
                boundary = nextElement.Bottom; // bottom
            }
            else
            {
                stop = true;
            }
        }
        return result;
    }
