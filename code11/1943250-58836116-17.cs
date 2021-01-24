    private PlayerMove playermove;
    IEnumerator StartSpawningCoins ()
    {
        // as long as you yield inside this is ok
        while(true)
        {
            // only do find if needed
            if(!player) player = GameObject.Find("PlayerMove");
            // this should probably actually be done in the prefab not via code
            coin.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(Random.Range(6f, 16f));
            GameObject k = Instantiate(coin);
            playermove.coincount++;
            float x = Random.Range(min_X,max_X);
            k.transform.position = new Vector2(x, transform.position.y);
        }
    }
