    using System.Collections.Generic;
    using UnityEngine;
    using System;
    
    public abstract class Poolable : MonoBehaviour
    {
        private static Dictionary<Type, Queue<Component>> objPool
            = new Dictionary<Type, Queue<Component>>();
    
        /// <summary>
        /// Get an object from the pool; If fails, use the alternative method to create one
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alternativeCreate"></param>
        /// <returns></returns>
        public static T Get<T>(Func<T> alternativeCreate) where T : Poolable
        {
            if (objPool.TryGetValue(typeof(T), out var queue) && queue.Count > 0)
            {
                var ret = queue.Dequeue() as T;
                ret.Reactive();
                return ret;
            }
            return alternativeCreate();
        }
    
        /// <summary>
        /// Return the object to the pool
        /// </summary>
        public void ReturnToPool()
        {
            if (this.Reset())
            {
                var type = this.GetType();
                Queue<Component> queue;
                if (objPool.TryGetValue(type, out queue))
                {
                    queue.Enqueue(this);
                }
                else
                {
                    queue = new Queue<Component>();
                    queue.Enqueue(this);
                    objPool.Add(type, queue);
                }
            }
        }
    
        /// <summary>
        /// Reset the object so it is ready to go into the object pool
        /// </summary>
        /// <returns>whether the reset is successful.</returns>
        protected virtual bool Reset()
        {
            this.gameObject.SetActive(false);
            return true;
        }
    
        /// <summary>
        /// Reactive the object as it goes out of the object pool
        /// </summary>
        protected virtual void Reactivate()
        {
            this.gameObject.SetActive(true);
        }
    }
