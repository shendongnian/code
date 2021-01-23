        public void FromWebClientRequest(int[] ids)
        {
            foreach (var id in ids)
            {
                Task.Factory.StartNew(() =>
                {
                    //do something with the id
                });
            }
        }
