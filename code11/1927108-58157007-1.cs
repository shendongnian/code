public static float demolishTime = 6.0f;
public void OnClickDemolish() {
    StartCoroutine(demolishProgress());
}
IEnumerator demolishProgress() {
    float progressedTime = 0f;
    // Assuming 'demolishTime' is the time taken to entirely demolish the thing.
    while (progressedTime < demolishTime) {
        yield return new WaitForEndOfFrame();
        progressedTime += Time.deltaTime;
        demolishProgressBar[DemolishManager.demolishState].fillAmount = Mathf.Lerp(0, 1, progressedTime);
    }
    demolishCompleted();
}
