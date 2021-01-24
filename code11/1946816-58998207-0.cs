private void FixedUpdate()
{
if (Input.GetKeyDown(KeyCode.Space))
                    SplitScreen();
}
public void SplitScreen()
    {
        if (StateQueue.TryDequeue(out var stateMsg))
            if (stateMsg.ID == 9)
            {
                // choose the margin randomly
                float margin = Random.Range(0.0f, 0.3f);
                // setup the rectangle
                sensorCamera.rect = new Rect(margin, 0.25f, 1.0f - margin * 2.0f, 0.25f);
                MainCamera.rect = new Rect(margin, 0.50f, 0.0f - margin * 2.0f, 0.25f);
            }
            else if (stateMsg.ID == 10)
            { // choose the margin randomly
                float margin = Random.Range(0.0f, 0.3f);
                // setup the rectangle
                sensorCamera.rect = new Rect(margin, 0.25f, 0.0f - margin * 2.0f, 0.25f);
                MainCamera.rect = new Rect(margin, 0.50f, 0.0f - margin * 2.0f, 0.25f);
            }
            else if (stateMsg.ID == 11)
            {
                // choose the margin randomly
                float margin = Random.Range(0.0f, 0.3f);
                // setup the rectangle
                sensorCamera.rect = new Rect(margin, 0.25f, 0.25f - margin * 2.0f, 0.25f);
                MainCamera.rect = new Rect(margin, 0.50f, 0.0f - margin * 2.0f, 0.25f);
            }
            else
            {
                Debug.Log("this didnt work");
            }
            
        }
