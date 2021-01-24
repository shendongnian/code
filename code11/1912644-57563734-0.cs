    // Update is called once per frame
    void Update()
    {
        if(hitted1){
            posi = new Vector3(42.49f, 0.5f, 163.8f); 
            player.transform.position = posi;
            hitted1 = false;
        }
    }
    
    void OnTriggerEnter(Collider other){
        if(other.name == "FPSController"){
            Debug.Log("player hit tele1");
            hitted1 = true;
        }
    }
