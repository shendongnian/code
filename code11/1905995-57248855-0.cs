    public class CreateCuts : MonoBehaviour
    {
        public GameObject cut;
        public float cutDestroyTime;
    
        private bool dragging = false;
        private Vector3 swipeStart;
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
                swipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0) && dragging)
            {
                createCut();
            }
        }
    
        private void createCut()
        {
            this.dragging = false;
            Vector3 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject cut = Instantiate(this.cut, swipeStart, Quaternion.identity);
            cut.GetComponent<LineRenderer>().positionCount = 2;
            // why is it not enabled by default if you just instantiate the gameobject O.o?
            cut.GetComponent<LineRenderer>().enabled = true;
            cut.GetComponent<LineRenderer>().SetPositions(new Vector3[]{
                new Vector3(swipeStart.x, swipeStart.y, 0),// z is zero cos we are in 2d in unity up axis is Y}
                new Vector3(swipeEnd.x, swipeEnd.y, 0)// z is zero cos we are in 2d in unity up axis is Y}
            });
            // Commented out cos atm we are "debugging" your linerenderer
            // Vector2[] colliderPoints = new Vector2[2];
            // colliderPoints[0] = new Vector2(0.0f, 0.0f);
            // colliderPoints[1] = swipeEnd - swipeStart;
            // cut.GetComponent<EdgeCollider2D>().points = colliderPoints;
            //Destroy(cut.gameObject, this.cutDestroyTime);
        }
    }
