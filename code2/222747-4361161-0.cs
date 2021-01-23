    class Oil : IMaterial
    {
        public string Apply(string surface)
        {
            return string.Format("painted with oil on {0}", surface);
        }
    }
