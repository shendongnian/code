    namespace SO_ProxyPool
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.Linq;
        using System.Threading.Tasks;
        sealed class ProxyPool
        {
            readonly object m_lock = new object ();
            readonly Random m_random = new Random ();
            readonly HashSet<string> m_usedProxies = new HashSet<string>();
            readonly HashSet<string> m_freeProxies = new HashSet<string>();
            volatile int m_minSize;
            public ProxyPool (IEnumerable<string> availableProxies)
            {
                m_freeProxies = new HashSet<string> (availableProxies);
                m_minSize = m_freeProxies.Count;
            }
            /// <summary>
            /// Reserves a proxy, returns null if no proxy is available
            /// </summary>
            /// <returns>The reserver proxy or null if no proxy is available</returns>
            public string ReserveProxy ()
            {
                lock (m_lock)
                {
                    if (m_freeProxies.Count == 0)
                    {
                        return null;
                    }
                    var index = m_random.Next (0, m_freeProxies.Count);
                    var proxy = m_freeProxies.ElementAt (index);
                    var removeSuccessful = m_freeProxies.Remove (proxy);
                    var addSuccessful = m_usedProxies.Add (proxy);
                    Debug.Assert (removeSuccessful);
                    Debug.Assert (addSuccessful);
                    m_minSize = Math.Min (m_minSize, m_freeProxies.Count);
                    return proxy;
                }
            }
            /// <summary>
            /// Returns the minimum size of the pool so far
            /// </summary>
            public int MinSize
            {
                get
                {
                    return m_minSize;
                }
            }
            /// <summary>
            /// Frees a reserved proxy
            /// </summary>
            /// <param name="proxy">The proxy to free</param>
            public void FreeProxy (string proxy)
            {
                if (proxy == null)
                {
                    return;
                }
                lock (m_lock)
                {
                    var removeSuccessful = m_usedProxies.Remove (proxy);
                    if (removeSuccessful)
                    {
                        var addSuccessful = m_freeProxies.Add (proxy);
                        Debug.Assert (addSuccessful);
                    }
                }
            }
        }
        class Program
        {
            static readonly ProxyPool s_proxyPool = new ProxyPool (
                new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", }
                );
            static string GetProxy ()
            {
                return s_proxyPool.ReserveProxy ();
            }
            static void FreeProxy (string proxy)
            {
                s_proxyPool.FreeProxy (proxy);
            }
            static void SimplisticTestCase ()
            {
                var proxy = GetProxy ();
                // Do something relevant...
                if (proxy != null)
                {
                    FreeProxy (proxy);
                }
            }
            static void Main (string[] args)
            {
                var then = DateTime.Now;
                const int count = 10000000;
                Parallel.For (0, count, idx => SimplisticTestCase ());
                var diff = DateTime.Now - then;
                Console.WriteLine (
                    "#{0} executions took {1:0.00}secs, pool min size {2}", 
                    count,
                    diff.TotalSeconds,
                    s_proxyPool.MinSize
                    );
            }
        }
    }
