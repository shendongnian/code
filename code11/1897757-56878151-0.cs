    static class MyExtensions {
        public static int FindSubArray(this Array x, Array y) {
            for (int i = 0; i < x.Length-y.Length+1; ++i) {
                var found = true;
                for (int j = 0; j < y.Length; ++j) {
                    if (!((IList)x)[i + j].Equals(((IList)y)[j])) {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return i;
            }
            return -1;
        }
    }
