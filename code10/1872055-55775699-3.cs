        public void RemoveBookFromISBN(string targetISBN)
        {
            var target = b.Find((x) => x.ISBN == targetISBN);
            if(target != null)
                b.Remove(target); 
        }
