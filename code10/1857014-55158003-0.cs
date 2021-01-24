private IEnumerator MoveLane(float x, float y)
{
    Vector2 initialPosition = transform.localPosition;
    Vector2 destination = new Vector2(x, y);
    float delta = 0;
    while(transform.localPosition != destination)
    {
        delta += Time.deltaTime * speedModifier;
        characterController.Move(Vector2.Lerp(initialPosition, destination, delta));
        yield return new WaitForEndOfFrame();
    }
}
Start this coroutine when you want to swap lanes, with x and y being the destination coordinate you want. You can adjust the speed with speedModifier (1 being "normal").
