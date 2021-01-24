    public Light[] stars;
    // Use a list for dynamically adding and removing items
    private List<Light> availableStars;
    private void Start()
    {
        // initialize the available list
        // copy the references from stars
        availableStars.AddRange(stars);
        StartCoroutine(ChooseStar());
    }
    private IEnumerator IncreaseRadius(Light star, float duration)
    {
        Debug.Log("Increasing: " + star.name + " radius: " + star.range);
        // As soon as you start animating this star
        // remove it from the list of availables
        availableStars.Remove(star);
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            star.range = counter;
            yield return null;
        }
        // Decreasing and at the same time wait for it to finish
        yield return DecreaseRadius(star);
        // when finished add the star again to the availables
        availableStars.Add(star);
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
        while (true)
        {
            var  duration = Random.Range(3.0f, 8.0f);
            var waitTime = 2f;
            // in case that currently all stars are being animated
            // simply wait until the next one becomes available again
            yield return new WaitUntil(() => availableStars.Count > 0);
            // Pick a random star from the availables instead
            var chosenStar = availableStars[Random.Range(0, availableStars.Count)];
            // this check becomes then actually redundant
            //if (chosenStar.range <= 0f)
            //{
            StartCoroutine(IncreaseRadius(chosenStar, duration));
            yield return new WaitForSeconds(waitTime);
            //}
        }
    }
