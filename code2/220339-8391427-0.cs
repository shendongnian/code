    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Xml;
    namespace xml.serialization
    {
    /// <summary>
    /// Class to serialize generic objects.
    /// </summary>
    public static class ObjectSerializer
    {
        /// <summary>
        /// Decode from xml string with default UTF8 encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T FromString<T>(string xml)
        {
            Encoding e = Encoding.UTF8;
            return FromString<T>(xml, e);
        }
        /// <summary>
        /// Decode from xml string with UTF16 unicode
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T FromStringUTF16<T>(string xml)
        {
            Encoding e = Encoding.Unicode;
            return FromString<T>(xml, e);
        }
        /// <summary>
        /// Decode from xml string with privided encoding type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T FromString<T>(string xml, Encoding e)
        {
            Object ret = null;
            XmlSerializer s = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(e.GetBytes(xml)))
            {
                XmlTextWriter xtWriter = new XmlTextWriter(stream, e);
                ret = s.Deserialize(stream);
                //xtWriter.Close();
            }
            return (T)ret;
        }
        /// <summary>
        /// Serialize to xml with default UTF8 encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString<T>(T obj)
        {
            Encoding e = Encoding.UTF8;
            return ToString(obj, e);
        }
        /// <summary>
        /// Serialize to xml with UTF16 encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringUTF16<T>(T obj)
        {
            Encoding e = Encoding.Unicode;
            return ToString(obj, e);
        }
        /// <summary>
        /// Serialize to xml with specified encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string ToString<T>(T obj, Encoding e)
        {
            string ret = String.Empty;
            XmlSerializer s = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            {
                XmlTextWriter xtWriter = new XmlTextWriter(stream, e);
                s.Serialize(xtWriter, obj);
                xtWriter.Close();
                ret = e.GetString(stream.ToArray());
            }
            return ret;
        }
        /// <summary>
        /// Serialize to xml to to a file with default UTF8 encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void ToXmlFile<T>(T obj, string filePath)
        {
            Encoding e = Encoding.UTF8;
            ToXmlFile<T>(obj, filePath, e);
        }
        /// <summary>
        /// Serialize to xml to to a file with specific encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <param name="e"></param>
        public static void ToXmlFile<T>(T obj, string filePath, Encoding e)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            using (TextWriter w = new StreamWriter(filePath, false, e))
            {
                s.Serialize(w, obj);
                w.Flush();
                w.Close();
            }
        }
        /// <summary>
        /// Deserialize from a file of xml useing default UTF8 encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T FromXmlFile<T>(string filePath)
        {
            Encoding e = Encoding.UTF8;
            return FromXmlFile<T>(filePath, e);
        }
        /// <summary>
        /// Deserialize from a file of xml useing specific encoding
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T FromXmlFile<T>(string filePath, Encoding e)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            Object ret = null;
            using (TextReader r = new StreamReader(filePath, e))
            {
                ret = s.Deserialize(r);
                r.Close();
            }
            return (T)ret;
        }
      }
    }
