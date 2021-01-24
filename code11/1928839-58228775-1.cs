void Update()
{
    hits = Physics2D.OverlapCircleAll(transform.position, 10);
    //...
}
You might also consider attaching a trigger collider to the enemy which sends a notification when the player enters/exits the trigger instead of relying on `OverlapCircleAll()`
void OnTriggerEnter2D(Collider2D col)
{
    if(col.gameObject.tag == "Player"){
        roam = false;
    }
}
void OnTriggerExit2D(Collider2D col)
{
    if(col.gameObject.tag == "Player"){
        roam = true;
    }
}
