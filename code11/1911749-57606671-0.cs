    using System.Collections.Generic;
    using UnityEngine;
    
    public class DottedLine : MonoBehaviour
    {
        Vector3 mp;
        Vector2 mousePosition;
        Vector2 start;
        public Sprite Dot;
        [Range(0.01f, 1f)]
        public float Size;
        [Range(0.1f, 2f)]
        public float Delta;
    
        List<Vector2> positions;
        List<GameObject> dots;
    
        private void Start()
        {
            start = new Vector2(transform.position.x, transform.position.y);
            positions = new List<Vector2>();
            dots = new List<GameObject>();
        }
    
        void Update()
        {
            mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector2(mp.x, mp.y);
            if (Input.GetMouseButtonDown(0))
            {
                DrawPoints(mousePosition);
            }
        }
    
        public void DrawPoints(Vector2 mousePosition)
        {
            DestroyAllDots();
    
            Vector2 point = start;
            Vector2 end;
            Vector2 direction = (mousePosition - start).normalized;
            RaycastHit2D ray = Physics2D.Raycast(start, direction);
            Vector3 rayPos = ray.point;
    
            float distance = Vector2.Distance(ray.transform.position, start);
            end = new Vector2(rayPos.x, rayPos.y);
            //Only needs one line drawn
            if (ray.collider.tag == "bottom" || ray.collider.tag == "bubble")
            {
                DrawOneLine(start, end, direction);
            }
            else if (ray.collider.tag == "wall")
            {
                //Will create a new line every time it hits a wall.
                DrawOneLine(start, end, direction);
    
                while (ray.collider.tag == "wall")
                {
                    Vector3 newRayPos = ray.point;
                    Vector2 newStart = new Vector2(newRayPos.x, newRayPos.y);
                    direction = Vector2.Reflect(direction, Vector2.right);
    
                    //I had to put in a tolerances so a new raycast could start,
                    //there is likely a better way, feedback appreciated.
                    Vector2 rightTol = new Vector2(-.001f, 0);
                    Vector2 leftTol = new Vector2(.001f, 0);
                    if (ray.collider.name == "Right Wall")
                        ray = Physics2D.Raycast(newStart + rightTol, direction);
                    else
                        ray = Physics2D.Raycast(newStart + leftTol, direction);
                    rayPos = ray.point;
                    end = new Vector2(rayPos.x, rayPos.y);
                    DrawOneLine(newStart, end, direction, false);
                }
            }
    
            Render();
        }
    
        public void DrawOneLine(Vector2 start, Vector2 end, Vector2 direction, bool drawFirst = true)
        {
            //Debug.Log($"Start: {start} End: {end} Direction: {direction}");
            Vector2 point = start;
            while ((end - start).magnitude > (point - start).magnitude)
            {
                if (drawFirst)
                    positions.Add(point);
                point += (direction * Delta);
                drawFirst = true;
            }
        }
    
        GameObject GetOneDot()
        {
            var gameObject = new GameObject();
            gameObject.transform.localScale = Vector3.one * Size;
            gameObject.transform.parent = transform;
    
            var sr = gameObject.AddComponent<SpriteRenderer>();
            sr.sprite = Dot;
            return gameObject;
        }
    
        private void Render()
        {
            foreach (var position in positions)
            {
                var g = GetOneDot();
                g.transform.position = position;
                dots.Add(g);
            }
        }
    
        public void DestroyAllDots()
        {
            foreach (var dot in dots)
                Destroy(dot);
            dots.Clear();
            positions.Clear();
        }
    }
