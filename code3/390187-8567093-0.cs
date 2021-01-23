        public int compareElementList(List<Element> elements)
        {
            int result = 0;
            for (int i = 0; i < elements.Count - 1; i++)
            {
                for (int q = i + 1; q < elements.Count; q++)
                {
                    result = Math.Max(result, compareElements(elements[i], elements[q]));
                }
            }
            return result;
        }
