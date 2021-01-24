    if (Input.GetKeyDown("e")){
        BoxCollider.enabled = false;  
        StartCoroutine(EnableCoroutine());      
    }
    ...
    IEnumerator EnableCoroutine() {
        //A coroutine can 'wait' until something is done
        //yield return null; would wait a single frame
        yield return new WaitForSeconds(2);
        
        //After 2 seconds the following code will be executed
        BoxCollider.enabled = true;
    }
