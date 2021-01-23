        private void Work()
        {
            var type = typeof(numbers);
            string [] members;
            
            if(type.IsEnum)
                members = typeof(numbers).GetEnumNames();
        }
        public enum numbers
        {
            one,
            two,
            three,
        }
