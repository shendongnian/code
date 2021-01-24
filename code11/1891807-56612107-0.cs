    public static class Collider2DExtension
    {
        /// <summary>
        /// Return the closest point on a Collider2D relative to point
        /// </summary>
        public static Vector2 ClosestPoint(this Collider2D col, Vector2 point)
        {
            GameObject go = new GameObject("tempCollider");
            go.transform.position = point;
            CircleCollider2D c = go.AddComponent<CircleCollider2D>();
            c.radius = 0.1f;
            ColliderDistance2D dist = col.Distance(c);
            Object.Destroy(go);
            return dist.pointA;
        }
    }
