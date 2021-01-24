    using System.Collections;
    using UnityEngine;
    
    public class Traveler : MonoBehaviour
    {
        [SerializeField] private float _movementDuration = 2.0f;
        [SerializeField] private Transform _wayPointOne = null;
        [SerializeField] private Transform _wayPointTwo = null;
        [SerializeField] private float _percentComplete = 0.0f;
    
        private void Start()
        {
            StartCoroutine(Move());
        }
    
        private IEnumerator Move()
        {
            var startMoveTime = Time.time;
            while (Time.time - startMoveTime < _movementDuration)
            {
                _percentComplete = (Time.time - startMoveTime) / _movementDuration;
                transform.position = Vector3.Lerp(_wayPointOne.position, _wayPointTwo.position, _percentComplete);
                yield return null;
            }
    
            transform.position = _wayPointTwo.transform.position;
        }
    }
