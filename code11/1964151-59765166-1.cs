    class RequesterInfo<T>
    {
        public string RequesterName { get; set; } // props you want to preserve
        public T RequestDto { get; set; } // props to be mapped 
    }
