            foreach (object collectionElement in myCollection)
            {
                if (ProcessElementAndDetermineIfStop(collectionElement))
                {
                    break;
                }
            }
            private bool ProcessElementAndDetermineIfStop(object collectionElement)
            {
                switch (v.id)
                {
                    case 1:
                        return true; // break cycle.
                    case 2;
                        return false; // do not break cycle.
                }
            }
