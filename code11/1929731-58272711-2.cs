private Coroutine _colorChanger;
private SpriteRenderer _renderer;
void Start() //Can be Awake, whichever you choose
{
    _renderer = GetComponent<SpriteRenderer>();
    if (_renderer == null)
    {
        Debug.Log("No sprite found.");
        return;
    }
    //This is performed if OnMouseDown is implemented, if you implement the Update with Input.GetKeyDown, then this can be removed
    var collider = GetComponent<Collider>();
    if (collider == null)
    {
        collider = gameObject.AddComponent<BoxCollider>(); //or BoxCollider2D if you are applying the script to the sprite itself.
    }
    collider.isTrigger = true;
}
private void OnMouseDown() //this can be swapped out for what Saif wrote, a Update method which checks if the button is down, should be GetKeyDown instead of GetKey, having it that way will eliminate the need for a collider/UI element
{
    if (_colorChanger == null)
    {
        _colorChanger = StartCoroutine(ChangeColor(2f));
    }
    else
    {
        StopCoroutine(_colorChanger);
        _colorChanger = null;
    }
}
IEnumerator ChangeColor(float timeoutSec)
{
    while (true)
    {
        yield return new WaitForSeconds(timeoutSec);
        int random = Random.Range(1, 5); //Change max from 4 to 5
        if (random == 1)
        {
            _renderer.color = Color.blue;
        }
        else if (random == 2)
        {
            _renderer.color = Color.red;
        }
        else if (random == 3)
        {
            _renderer.color = Color.green;
        }
        else
        {
            _renderer.color = Color.yellow;
        }
    }
}
Update: just noticed something that others missed, you should change the `Random.Range(1, 4)` to `Random.Range(1, 5)` or else the yellow color will never come into effect.
