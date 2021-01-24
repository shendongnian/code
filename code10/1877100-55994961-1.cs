private void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag != "Player") 
    {
        Destroy(gameObject);
    }
}
and then go to the player object and create a new Layer called "Player", and assign it to the player object.
