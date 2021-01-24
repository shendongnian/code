    using UnityEngine;
    using System.Collections;
    public class CameraRotate : MonoBehaviour
    {
        public float speed;
        float time = 5.0f;
        public bool updateOn = true;
    void Start()
    {
        StartCoroutine(updateOff());
    }
    void Update()
    {
        if (updateOn == true)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {
                transform.Rotate(0, -speed * Time.deltaTime, 0);
            }
        }
    }
        IEnumerator updateOff()
        {
            yield return new WaitForSeconds(10.0f);
            updateOn = false;
        }
    }
