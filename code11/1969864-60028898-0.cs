    void Start() {
        controller = GetComponent<Controller2D>();  // Je krijgt toegang tot de script Controller2D
        
        stream.ReadTimeout = 100;
        
        stream.Open();  // Uw serialpoort openen
        Thread sampleThread = new Thread(new ThreadStart(sampleFunction));
        sampleThread.IsBackground = true;
        sampleThread.Start();
    }
    void Update() {
        //if (stream.IsOpen) {    // Als uw serialpoort open is
        //    try {
                
        //        arduinoInput = (byte)stream.ReadByte();
        //        //print(arduinoInput);
        //        Debug.Log(arduinoInput);
        //    }
        //    catch (System.Exception) {
        //    }
        //}
        if (arduinoInput == 2) {       // Als je de 2de drukknop indrukt
            moveDistance.x = -moveSpeed;   // Ga je links bewegen
            controller.Move(moveDistance * Time.deltaTime);     // Leest de input
        }
        if (arduinoInput == 3) {       // Als je de 3de druknop indrukt
            moveDistance.x = moveSpeed;     // Ga je rechts bewegen
            controller.Move(moveDistance * Time.deltaTime);     // Leest de input
        }
        if (controller.collisions.above || controller.collisions.below ) {   // Als je een botsing hebt van boven of beneden dan ga je stoppen met springen
            moveDistance.y = 0;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || arduinoInput == 1) && controller.collisions.below) {   // Als je op spatie drukt en als je op een platform staat dan ga je boven springen
            moveDistance.y = jumpDistance;  // Je gaat springen langs de y-as
            //moveDistance.x = 0;     // Als je alleen springt dan ga je loodrecht boven en niet schuin
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  // Je neemt de Horizontal en vertical inputs van de unity zelf
        moveDistance.x = input.x * moveSpeed;   // Door input kan je nu links of rechts bewegen met de pijlen
        moveDistance.y += gravity * Time.deltaTime;     // Je valt met een zwaartekracht dus je gaat sneller en sneller vallen.       
        controller.Move(moveDistance * Time.deltaTime);     // Leest de input 
        
    }
    public void sampleFunction() {
        while (true) {
            if (stream.IsOpen) {    // Als uw serialpoort open is
                try {
                    arduinoInput = (byte)stream.ReadByte();
                    //print(arduinoInput);
                    Debug.Log(arduinoInput);
                }
                catch (System.Exception) {
                }
            }
        }
    }
