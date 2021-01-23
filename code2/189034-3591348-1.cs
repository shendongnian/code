        public void sortAlphabet() {
            using (var enu = getAlphabet().GetEnumerator()) {
                while (enu.MoveNext()) {
                    switch (enu.Current) {
                        case 'A':
                            enu.MoveNext();
                            _nextChar = enu.Current;
                            break;
                    }
                }
            }
        }
