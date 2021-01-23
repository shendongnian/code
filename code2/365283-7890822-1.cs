    public static class  MaterialsExtemsion
    {
        public static bool IsWalkable(this Materials material)
        {
            var attribute = material.GetType().GetCustomAttributes(typeof (WalkableAttribute), false).FirstOrDefault();
            return attribute != null && ((WalkableAttribute) attribute).IsWalkable;
        }
    }
