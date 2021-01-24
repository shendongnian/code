    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Helps dispatch task results to the main thread to be able to operate on unity's API like SetActive, enabled etc...
    /// </summary>
    public class MainThreadDispatcher : MonoBehaviour
    {
        Queue<Action> jobs = new Queue<Action>();
        static MainThreadDispatcher Instance = null;
    
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
            while (jobs.Count > 0)
                jobs.Dequeue()?.Invoke();
        }
        /// <summary>
        /// Dispatches a function to be executed on unity's main thread to be able to use unity's API.
        /// </summary>
        /// <param name="newJob"></param>
        public static void Dispatch(Action newJob)
        {
            if (newJob == null)
                return;
            Instance.jobs.Enqueue(newJob);
        }
    }
