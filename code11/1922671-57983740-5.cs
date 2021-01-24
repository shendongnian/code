     // define all locations you want to check in order
     public Vector3[] checkPositions;
     // radius to check for, depending on block size
     public float blockSize = 1.0f
     
     foreach (Vector3 checkPos in checkPositions) {
         if (Physics.CheckSphere (checkPos, blockSize)) {
             // found something
             Debug.Log('cannot spawn here!', checkPos);
         } else {
             // spot is empty, we can spawn
             refhead.transform.position = checkPos;
             head = (GameObject)Instantiate(refhead, parentTransform);
             break;
         }
     }
     
