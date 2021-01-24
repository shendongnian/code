C#
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
public class ABDownloader : MonoBehaviour
{
    public static GameObject s_GearObject;
    private static bool s_CacheCleared = false;
    public string m_Url;
    public Text m_LoadingText;
    private void Awake()
    {
        if (!s_CacheCleared)
        {
            s_CacheCleared = true;
            Caching.ClearCache();
        }
        Assert.IsNotNull(m_LoadingText, "[ABDownloader] Missing UGUI component: LoadingText");
        if (string.IsNullOrEmpty(m_Url))
        {
            Debug.LogError("[ABDownloader] Invalid URL!");
        }
        else
        {
            m_Url = m_Url.ToLowerInvariant();
        }
    }
    public void Load(string gearName)
    {
        if (s_GearObject != null)
        {
            Destroy(s_GearObject);
        }
        m_LoadingText.text = "Loading...";
        StartCoroutine(LoadBundle(gearName));
    }
    private IEnumerator LoadBundle(string gearName)
    {
        while (!Caching.ready)
        {
            yield return null;
        }
        gearName = gearName.ToLowerInvariant();
        if (gearName.StartsWith("assets/"))
        {
            Debug.LogError("[ABDownloader] Please give the asset's full path: " + gearName);
            yield break;
        }
        AssetBundle assetBundle = null;
        // Try load from localhost
        if (m_Url.StartsWith("assets/"))
        {
            if (File.Exists(m_Url))
            {
                var abrq = AssetBundle.LoadFromFileAsync(m_Url);
                yield return abrq;
                if (!abrq.isDone || abrq.assetBundle == null)
                {
                    Debug.LogError("[ABDownloader] The assetBundle doesn't exist: " + m_Url);
                    yield break;
                }
                assetBundle = abrq.assetBundle;
            }
        }
        else
        {
            // Download AssetBundle from server
            WWW www = new WWW(m_Url);
            yield return www;
            if (!www.isDone || !string.IsNullOrEmpty(www.error))
            {
                Debug.LogError("[ABDownloader] Download assetBundle error: " + www.error + ", please check the URL or Network: " + m_Url);
                yield break;
            }
            // TODO: Save assetBundle to Application.persistentDataPath
            File.WriteAllBytes(Application.persistentDataPath + "/" + Path.GetFileName(m_Url), www.bytes);
            assetBundle = www.assetBundle;
            www.Dispose();
        }
        AssetBundleRequest bundleRequest = assetBundle.LoadAssetAsync<GameObject>(gearName);
        yield return bundleRequest;
        if(!bundleRequest.isDone || bundleRequest.asset == null)
        {
            Debug.LogError("[ABDownloader] Load asset from AssetBundle error: " + gearName);
            yield break;
        }
        GameObject obj = bundleRequest.asset as GameObject;
        s_GearObject = Instantiate(obj) as GameObject;
        m_LoadingText.text = "";
        assetBundle.Unload(false);
        Debug.Log("[ABDownloader] Load asset OK!");
    }
}
