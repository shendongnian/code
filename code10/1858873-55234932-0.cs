    public Color[] colors; // allows input of material colors in a set sized array
        public SpriteRenderer rend;  // what are we rendering? the hex
        private int index = 1; //initialize at 1, otherwise you have to press the ball twice to change color
        // Use this for initialization
        void Start()
        {
            rend = GetComponent<SpriteRenderer>(); // gives functionality for the renderer
        }
        // Update is called once per frame
        void OnMouseDown()
        {
            // if there are no colors present nothing happens
            if (colors.Length == 0)
            {
                return;
            }
            
                index += 1; // when mouse is pressed down we increment up to the next index location
                // when it reaches the end of the colors it stars over
                if (index == colors.Length + 1)
                {
                    index = 1;
                }
                print(index); // used for debugging
                rend.color = colors[index - 1]; // this sets the material color values inside the index
            
        } //onMouseDown
