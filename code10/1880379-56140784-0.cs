csharp
void OnCollisionEnter2D(Collision2D Col)
{
    Thread.Sleep(5000) // 5000 in milliseconds
    if (Col.collider.tag == "Enemy")
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
        StartCoroutine("RestartGameCo");
    }
}
public IEnumerator RestartGameCo()
{
    Thread.Sleep(5000)
    yield return new WaitForSeconds(0.5f);
    SceneManager.LoadScene("Level1");
}
