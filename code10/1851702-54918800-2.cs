C#
using System.Collections;
using UnityEngine;
public class ABDownloader : MonoBehaviour
{
    public static GameObject s_GearObject;
    private static bool s_CacheCleared = false;
    public string m_Url = "https://drive.google.com/uc?export=download&id=1j_iAg2ESHyNLL62CXYHb40p_X9C1oDM5";
    public string m_AssetName = "assets/prefab/h_gear.prefab";
    private void Awake()
    {
        if (!s_CacheCleared)
        {
            s_CacheCleared = true;
            Caching.ClearCache();
        }
        if (string.IsNullOrEmpty(m_Url))
        {
            Debug.LogError("[ABDownloader] Invalid URL!");
        }
        Load(m_AssetName);
    }
    private void Load(string gearName)
    {
        if (s_GearObject != null)
        {
            Destroy(s_GearObject);
        }
        StartCoroutine(LoadBundle(gearName));
    }
    private IEnumerator LoadBundle(string gearName)
    {
        while (!Caching.ready)
        {
            yield return null;
        }
        gearName = gearName.ToLowerInvariant();
        if (!gearName.StartsWith("assets/"))
        {
            Debug.LogError("[ABDownloader] Please give the asset's full path: " + gearName);
            yield break;
        }
        AssetBundle assetBundle = null;
        WWW www = WWW.LoadFromCacheOrDownload(m_Url, 0);
        yield return www;
        if (!www.isDone || !string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("[ABDownloader] Download assetBundle error: " + www.error + ", please check the URL or Network: " + m_Url);
            yield break;
        }
        assetBundle = www.assetBundle;
        AssetBundleRequest bundleRequest = assetBundle.LoadAssetAsync<GameObject>(gearName);
        yield return bundleRequest;
        if (!bundleRequest.isDone || bundleRequest.asset == null)
        {
            Debug.LogError("[ABDownloader] Load asset from AssetBundle error: " + gearName);
            yield break;
        }
        GameObject obj = bundleRequest.asset as GameObject;
        s_GearObject = Instantiate(obj) as GameObject;
        assetBundle.Unload(false);
        Debug.Log("[ABDownloader] Load asset OK!");
    }
}
