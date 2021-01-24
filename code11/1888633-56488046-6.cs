    public Light[] stars;
    private void Start()
    {
        StartCoroutine(ChooseStar());
    }
    private IEnumerator IncreaseRadius(Light star, float duration)
    {
        Debug.Log("Increasing: " + star.name + " radius: " + star.range);
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            star.range = counter;
            yield return null;
        }
        // again do the decreasing and at the same time wait for it to finish
        yield return DecreaseRadius(star);
    }
    private static IEnumerator DecreaseRadius(Light star)
    {
        Debug.Log("Decreasing: " + star.name + " radius: " + star.range);
        var counter = star.range;
        while (star.range >= 0f)
        {
            counter -= Time.deltaTime;
            star.range = counter;
            yield return null;
        }
        star.range = 0f;
    }
    IEnumerator ChooseStar()
    {
        // Looks scary but is totally fine in Coroutines as long as you yield somewhere
        // instead of starting a new Coroutine simple continue the one you already have
        while (true)
        {
            var duration = Random.Range(3.0f, 8.0f);
            var choosenStar = stars[Random.Range(0, stars.Length)];
            // This starts the Increase routine on that star
            // and at the same time waits for it to finish!
            //
            // since we also wait until DecreaseRadius is done this means 
            // at any time only exactly 1 star is animated at the same time
            yield return IncreaseRadius(choosenStar, duration);
        }
    }
