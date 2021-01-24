    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class Spawn : MonoBehaviour
    {
    
        [SerializeField]
        public GameObject coin;
    
        [SerializeField]
        float fMinTimeInterval;
    
        [SerializeField]
        float fMaxTimeInterval;
    
        [SerializeField]
        Vector2 v2SpawnPosJitter;
    
        float fTimer = 0;
    
        public CurrencyManager cm;
    
    
        // Start is called before the first frame update
        void Start()
        {
            ResetTimer();
        }
    
        // Update is called once per frame
        void Update()
        {
    
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                ResetTimer();
                Vector2 v2SpawnPos = transform.position;
                v2SpawnPos += Vector2.right * v2SpawnPosJitter.x * (Random.value - 0.5f);
                v2SpawnPos += Vector2.up * v2SpawnPosJitter.y * (Random.value - 0.5f);
                GameObject cmscript = Instantiate(coin, v2SpawnPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                cmscript.GetComponent<AutoDestroy>().CM = cm;
            }
        }
    
        void ResetTimer()
        {
            fTimer = Random.Range(fMinTimeInterval,fMaxTimeInterval);
        }
    }
