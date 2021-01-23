            int blockSize = 100;
            int i = 0;
            IEnumerable<IEnumerable<string>> query = from s in lines
                                                    let num = i++
                                                    group s by num / blockSize into g
                                                    select g;
            foreach(IEnumerable<string> stringBlock in query)
            {
                // Stringblock will be a block of 100 elements.
                // Process this 100 elements here.
            }
