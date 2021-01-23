    public static class  MaterialsExtemsion
    {
        public static bool IsWalkable(this Materials material)
        {
            var attribute = material.GetType().GetMember(material.ToString()).First().GetCustomAttributes(typeof(WalkableAttribute), false).FirstOrDefault();
            return attribute != null && ((WalkableAttribute) attribute).IsWalkable;
        }
    }
