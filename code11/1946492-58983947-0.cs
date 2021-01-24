    for (int i = 0; i < howManyYellow; i++)
    {
        tmpYellow = Instantiate(YellowPrefab, 
                                new Vector3(Random.Range(-50, 50), 
                                Random.Range(-40, -17), 0), 
                                Quaternion.identity);
        BoxCollider2D tmpYCollider = tmpYellow.GetComponent<BoxCollider2D>();
        
        // while collider overlaps, move your object somewhere else (e.g. 17 units up)
	    while (Physics2D.OverlapBox(tmpYCollider.bounds.center, tmpYCollider.size, 0) != null)
	    {
            tmpYellow.transform.Translate(new Vector3(0, 17));
            // or do something else
		}
    }
