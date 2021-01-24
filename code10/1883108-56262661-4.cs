    for (int i = 1; i < 6; i++)
    {
        rockets.Clear();
        GameObject rocketspawnblue = Instantiate(
                rocketblue, 
                new Vector3(Random.Range(-15, 15), (Random.Range(-15, 15))), 
                Quaternion.identity);
        SpriteRenderer rocketscolor1 = rocketspawnblue.GetComponent<SpriteRenderer>();
        //rocketscolor.color = colors[Random.Range(0,colors.Length)];
        rocketscolor1.color = Color.blue;
        rockets.Add(rocketspawnblue);
        GameObject rocketspawnred = Instantiate(
                rocketred, 
                new Vector3(Random.Range(-15, 15), (Random.Range(-15, 15))), 
                Quaternion.identity);
        SpriteRenderer rocketscolor2 = rocketspawnred.GetComponent<SpriteRenderer>();
        //rocketscolor.color = colors[Random.Range(0, colors.Length)];
        rocketscolor2.color = Color.red;
        rockets.Add(rocketspawnred);
        while (AnyRocketsLeft()) {
            yield return null;
        }
    }
    // ran out of rockets
    // set up the "next level" prompt, etc. here
