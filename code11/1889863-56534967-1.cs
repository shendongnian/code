C#
void OnCollisionEnter2D(Collision2D collision)
{   //Check if the brick has already been processed
    if (collision.transform.CompareTag("Brick") && collision.collider.enabled) 
    {
        Debug.Log("Brick Hit");
        //Chance of powerup to spawn
        int rand = Random.Range(1, 101);
        //Chance of each power up
        int rand2 = Random.Range(1, 101);
        if (rand < 7)
        {
            if (rand2 >=1 && rand2<=20) {
                Instantiate(SpeedBall, collision.transform.position, collision.transform.rotation);
                //Debug.Log(" Speed Power Up Created ");
            }
            ...
            Rest of  power ups
            ...
        }
        Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        Destroy(newExplosion.gameObject, 2f);
        gm.UpdateBrickNumber();
        //Mark the brick as hit already so other balls can't hit it!
        collision.collider.enabled = false; 
        Destroy(collision.gameObject);
    }
}
<h2>Explanation</h2>
From the [documentation][1]:
> Actual object destruction is always delayed until after the current Update loop, but will always be done before rendering.
`Destroy` is not instant. It will take place after the update loop, meaning if two balls hit in the same frame, you're reducing your count by two, but only destroying one brick.
  [1]: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
