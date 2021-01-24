        /// <summary>
        /// Generate random correlation ID(xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\xxxxx)
        /// </summary>
        /// <returns>string</returns>
        /// <param name="id">if want specific id in end of generated id, else it will be random forom 1- 10000</param>
        public string GenerateId(int id = 0)
        {
            if (id == 0)
            {
                Random r = new Random();
                id = r.Next(1, 10000);
                id = r.Next(1, 10000);
            }
            return $"{Guid.NewGuid().ToString()}\\{id.ToString()}";
        }
