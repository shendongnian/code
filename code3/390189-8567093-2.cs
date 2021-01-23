        public int compareElementEnumerable(IEnumerable<Element> elements)
        {
            int result = 0, i = 0, q = 1;
            foreach (Element el in elements)
            {
                foreach (Element el2 in elements)
                {
                    if (q > i)
                    {
                        result = Math.Max(result, compareElements(el, el2));
                    }
                    q++;
                }
                i++;
            }
            return result;
        }
